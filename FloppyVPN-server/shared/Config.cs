﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace FloppyVPN
{
	public static class Config
	{
		private static readonly string ConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CONFIG.XML");
		private static readonly string rootName = "Config";
		public static DataRow cache = null;

		/// <summary>
		/// If there is no CONFIG.XML but there is CONFIG.XML.TEMPLATE, copy it to CONFIG.XML
		/// </summary>
		public static void EnsureFileIntegrity(bool doNotWarnButJustCopyConfig = false)
		{
			string pathToConfig = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CONFIG.XML"));
			string pathToTemplate = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CONFIG.XML.TEMPLATE"));
			
			if (!File.Exists(pathToConfig) && File.Exists(pathToTemplate))
			{
				File.Copy(pathToTemplate, pathToConfig);

				if (!doNotWarnButJustCopyConfig)
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine("WARNING! The configuration file is empty. It is now created from the backup BUT you must fill it with your actual data before attempting to start the server.");
					Console.ReadLine();

					Environment.Exit(0);
				}
			}
			else if (!File.Exists(pathToConfig) && !File.Exists(pathToTemplate))
			{
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("ERROR! Can't find neither CONFIG.XML, nor CONFIG.XML.TEMPLATE. Files may be missing. Can not continue.");
				Console.ReadLine();

				Environment.Exit(1);
			}
		}

		public static void CacheRefresher()
		{
			for (; ; )
			{
				cache = LoadDataTable(ConfigFilePath).Rows[0];
				Thread.Sleep(15 * 1000);
			}
		}

		public static string? Get(string key)
		{
			if (!File.Exists(ConfigFilePath))
			{
				CreateConfigFile();
				return null;
			}

			XElement root = XElement.Load(ConfigFilePath);
			XElement? element = root.Element(key);
			try
			{
				return element?.Value;
			}
			catch
			{
				return null;
			}
		}

		public static void Set(string key, string value)
		{
			XElement root;
			if (File.Exists(ConfigFilePath))
			{
				root = XElement.Load(ConfigFilePath);
			}
			else
			{
				root = new XElement(rootName);
			}

			XElement? element = root.Element(key);
			if (element == null)
			{
				root.Add(new XElement(key, value));
			}
			else
			{
				element.Value = value;
			}

			root.Save(ConfigFilePath);
		}

		private static void CreateConfigFile()
		{
			XElement root = new(rootName);
			root.Save(ConfigFilePath);
		}

		public static DataTable LoadDataTable(string xmlFilePath)
		{
			DataTable dataTable;

			// Load XML data into a DataSet
			DataSet dataSet = new();
			dataSet.ReadXml(xmlFilePath);

			// Assuming one XML = one DataTable
			if (dataSet.Tables.Count > 0)
			{
				dataTable = dataSet.Tables[0];
			}
			else
			{
				throw new ArgumentException("No DataTable found in the XML file.");
			}

			return dataTable;
		}
	}

}