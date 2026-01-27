Создание UI модульных тестов
План работы:

Создать простое MAUI-приложение авторизации

Создать проект xUnit:
Добавить в созданный проект Nuget пакеты:
  Appium.WebDriver
  Selenium.Support
Собрать APK созданного приложения в режиме Debug (В свойствах проекта убрать галочку быстрое развертывание)
<img width="452" height="140" alt="image" src="https://github.com/user-attachments/assets/ff678950-3190-4a16-b0ff-2564354e54e9" />

Скопировать путь до APK

Установка среды эмуляции:
Установить Node.js https://nodejs.org/
Установить сервер Appium (по отдельности) через PowerShell в VisualStudio:
  npm install -g appium
  appium driver install uiautomator2

Совязываем Windows и Visual Studio:
Параметры → Система → О системе → Дополнительные параметры системы → Переменные среды
Добавляем параметры (ссылка где находятся SDK android):
+ANDROID_HOME
C:\Users\<USERNAME>\AppData\Local\Android\Sdk
+ANDROID_SDK_ROOT
C:\Users\<USERNAME>\AppData\Local\Android\Sdk
И добавляем инструменты в PATH
%ANDROID_HOME%\platform-tools
%ANDROID_HOME%\emulator
%ANDROID_HOME%\cmdline-tools\latest\bin

Перезапустить ПК!!!

Готов для того чтобы запустить UI тесты неоходимо их написать, а также:
Запусти Android Emulator
Запусти Appium server (отдельный терминал команда "appium")
Запустить тесты в Visual studio (Важно чтобы APK был последней сборки)
