namespace FloppyVPN
{
	/// <summary>
	/// Localization utility and resource
	/// </summary>
	/// 
	public static class Loc
	{
		public static string lang = "en";


		public static string connect = "";
		public static string disconnect = "";
		public static string errorConnectingCaption = "";
		public static string statusNotConnected = "";
		public static string statusConnected = "";
		public static string cantFindDriver = "";
		public static string fileMenu = "";
		public static string optionsMenu = "";
		public static string helpMenu = "";
		public static string websiteButton = "";
		public static string exitButton = "";
		public static string connectionGroup = "";
		public static string accountGroup = "";
		public static string addTimeButton = "";
		public static string startupButton = "";
		public static string languageButton = "";
		public static string startupStatusAdded = "";
		public static string startupStatusNotAdded = "";
		public static string addToStartup = "";
		public static string removeFromStartup = "";
		public static string loginButton = "";
		public static string logoutButton = "";
		public static string updateButton = "";
		public static string logoutPrompt = "";
		public static string alreadylaunched = "";
		public static string close = "";
		public static string register = "";
		public static string loginCaption = "";
		public static string loginGroup = "";
		public static string unableToLogInText = "";
		public static string unableToLoginCaption = "";
		public static string refreshbutton = "";
		public static string revealIP = "";
		public static string currentIP = "";
		public static string yes = "";
		public static string no = "";
		public static string cancel = "";
		public static string retry = "";
		public static string publicIP = "";
		public static string privateIP = "";
		public static string x = "";

		public static void Alize()
		{
			switch (lang)
			{
				default:
					connect = "&Connect";
					disconnect = "Dis&connect";
					errorConnectingCaption = "Could not connect";
					statusNotConnected = "Disconnected";
					statusConnected = "Connected";
					cantFindDriver = "Could not find wg.exe. Fatal.\nSome installation files may be missing.";
					fileMenu = "&File";
					optionsMenu = "&Options";
					helpMenu = "&Help";
					websiteButton = "Website...";
					exitButton = "Disconnect and Exit";
					connectionGroup = "Connection ";
					accountGroup = "Account ";
					addTimeButton = "Add time...";
					startupButton = "Startup";
					languageButton = "Language";
					startupStatusAdded = "Currently added to Startup!";
					startupStatusNotAdded = "Currently NOT added to Startup";
					addToStartup = "Add to Startup";
					removeFromStartup = "Remove from Startup";
					loginButton = "Log in";
					logoutButton = "Log out";
					updateButton = "Check for updates...";
					logoutPrompt = "You are going to log out from your account, it's is NOT for closing the application.";
					alreadylaunched = "FloppyVPN already launched!";
					close = "Close";
					register = "Register...";
					loginCaption = "Please enter your login to sign in.\nIf you don't have an account, register one in a minute";
					loginGroup = "Log in first. ";
					unableToLoginCaption = "Unable to log in.";
					unableToLogInText = "Please verify that the account exists and the balance is not zero. Otherwise, there are problems with connection on your or on a server side.";
					refreshbutton = "Refresh";
					revealIP = "Reveal IP";
					currentIP = "Current IP:";
					yes = "Yes";
					no = "No";
					cancel = "Cancel";
					retry = "Retry";
					publicIP = "Public IP: ";
					privateIP = "Private IP: ";

					break;
				case "ru":
					connect = "&Подключить";
					disconnect = "&Отключить";
					errorConnectingCaption = "Не удалось подключить";
					statusNotConnected = "Отключено";
					statusConnected = "Подключено";
					cantFindDriver = "Не удалось найти wg.exe. Критично.\nНекоторых файлов установки явно недостаёт.";
					fileMenu = "Файл";
					optionsMenu = "Опции";
					helpMenu = "Помощь";
					websiteButton = "Сайт...";
					exitButton = "Отрубиться и выйти";
					connectionGroup = "Подключение ";
					accountGroup = "Аккаунт ";
					addTimeButton = "Добавить время...";
					startupButton = "Автозапуск";
					languageButton = "Language";
					startupStatusAdded = "Добавлено в автозапуск!";
					startupStatusNotAdded = "сейчас НЕ добавлен в автозапуск";
					addToStartup = "Добавить в автозапуск";
					removeFromStartup = "Убрать из автозапуска";
					loginButton = "Войти";
					logoutButton = "Выйти";
					updateButton = "Проверить обновления...";
					logoutPrompt = "Точно выйти из аккаунта? (Это не кнопка для закрытия программы)";
					alreadylaunched = "FloppyVPN уже запущен!";
					close = "Закрыть";
					register = "Регистрация...";
					loginCaption = "Пожалуйста, введите свой логин, чтобы войти.\nЕсли у вас его нет, зарегистрируйтесь за минуту";
					loginGroup = "Прежде всего, войдите. ";
					unableToLoginCaption = "Не удалось войти.";
					unableToLogInText = "Убедитесь, что логин правильный, а аккаунт пополнен. Иначе - проблема в подключении на вашей стороне или стороне сервера.";
					refreshbutton = "Обновить";
					revealIP = "Показать IP";
					currentIP = "Текущий IP:";
					yes = "Да";
					no = "Нет";
					cancel = "Отмена";
					retry = "Повтор";
					publicIP = "Публичный IP: ";
					privateIP = "Приватный IP: ";

					break;
				case "uk":
					connect = "Під'єднати";
					disconnect = "Роз'єднати";
					errorConnectingCaption = "Не владося під'єднати";
					statusNotConnected = "Від'єднано";
					statusConnected = "Під'єднано";
					cantFindDriver = "Не вдалося знайти wg.exe. Це недобре...\nДеякі файли встановлення загублені.";
					fileMenu = "Файл";
					optionsMenu = "Опції";
					helpMenu = "Допомога";
					websiteButton = "Вебсайт...";
					exitButton = "Відрубити та вийти";
					connectionGroup = "Підключення ";
					accountGroup = "Акаунт ";
					addTimeButton = "Додати часу...";
					startupButton = "Автостарт";
					languageButton = "Мова";
					startupStatusAdded = "Наразі у автозапуску!";
					startupStatusNotAdded = "Наразі не у автозапуску";
					addToStartup = "Додати до автозапуску";
					removeFromStartup = "Вилучити з автозапуску";
					loginButton = "Увійти";
					logoutButton = "Вийти";
					updateButton = "Перевірити на оновлення...";
					logoutPrompt = "Точно вийти з акаунту? (Це не кнопка для закриття програми)";
					alreadylaunched = "FloppyVPN вже запущено!";
					close = "Закрити";
					register = "Реєстрація...";
					loginCaption = "Будь ласка, введіть свій логін, щоб увійти.\nЯкщо у вас його немає, зареєструйтесь за хвилину";
					loginGroup = "Перш за все, увійдіть. ";
					unableToLoginCaption = "Не вдалося увійти.";
					unableToLogInText = "Переконайтеся, що логін правильний, а акаунт поповнено. Інакше - проблеми з підключенням на вашій або нашій стороні.";
					refreshbutton = "Оновити";
					revealIP = "Показати IP";
					currentIP = "Поточний IP:";
					yes = "Так";
					no = "Ні";
					cancel = "Відміна";
					retry = "Повтор";
					publicIP = "Публічний IP: ";
					privateIP = "Приватний IP: ";

					break;
				case "ja":
					connect = "プラグ";
					disconnect = "プラグを抜く";
					errorConnectingCaption = "接続に失敗しました";
					statusNotConnected = "無効";
					statusConnected = "接続されている";
					cantFindDriver = "Wgが見つかりませんでした。wg.exe\n重要だ。\nいくつかのインストールファイルが明らかに欠落しています。";
					fileMenu = "File";
					optionsMenu = "Options";
					helpMenu = "Help";
					websiteButton = "ウェブサイト...";
					exitButton = "切断と終了";
					connectionGroup = "接続 ";
					accountGroup = "アカウント ";
					addTimeButton = "月を追加...";
					startupButton = "自動起動";
					languageButton = "Language";
					startupStatusAdded = "スタートアップに追加";
					startupStatusNotAdded = "スタートアップに追加されない";
					addToStartup = "スタートアップに追加";
					removeFromStartup = "スタートアップから削除";
					loginButton = "ログイン";
					logoutButton = "ログアウト";
					updateButton = "更新の確認...";
					logoutPrompt = "あなたはあなたのアカウントからログアウトしますか？";
					alreadylaunched = "FloppyVPNはすでに実行されています！";
					close = "閉じるには";
					register = "登録...";
					loginCaption = "ログインするには、ユーザー名を入力してください。\nお持ちでない場合は、すぐに登録してください";
					loginGroup = "まず、ログインします ";
					unableToLoginCaption = "ログインに失敗しました。";
					unableToLogInText = "ログインが正しく、アカウントが補充されていることを確認してください。 それ以外の場合、問題はあなたの側またはサーバー側の接続です。";
					refreshbutton = "更新";
					revealIP = "IPを表示";
					currentIP = "現在のIP:";
					yes = "はい。";
					no = "いいえ。";
					cancel = "キャンセル";
					retry = "また！";
					publicIP = "パブリックIP: ";
					privateIP = "プライベートIP: ";

					break;
			}
		}
	}
}