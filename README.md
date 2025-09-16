# WPF Beispielprojekt: Taschenrechner

Dieses Projekt ist ein einfacher Taschenrechner als WPF-Anwendung. Es dient als Einstieg und Lernhilfe für Auszubildende, die mit Windows Presentation Foundation (WPF) arbeiten möchten.

## Voraussetzungen

- Windows PC
- [Visual Studio 2022 (Community reicht aus)](https://visualstudio.microsoft.com/de/vs/)
- .NET 6 oder neuer (im Visual Studio Installer auswählbar)

## Projekt öffnen

1. Repository klonen oder herunterladen
2. Die Datei `Taschenrechner.sln` mit Visual Studio öffnen
3. Projekt kompilieren (`F5` oder grüner Start-Button)

## Schritt-für-Schritt-Anleitung

### 1. Was ist WPF?

WPF (Windows Presentation Foundation) ist ein Framework von Microsoft, um moderne Desktop-Anwendungen für Windows zu entwickeln. Es trennt das User Interface (XAML) vom Code (C#).

### 2. Projektstruktur

- **App.xaml / App.xaml.cs**: Einstiegspunkt der Anwendung
- **MainWindow.xaml**: Definiert das Aussehen (UI) des Hauptfensters
- **MainWindow.xaml.cs**: Enthält die Logik für das Hauptfenster

### 3. Oberfläche verstehen

In `MainWindow.xaml` sind Buttons und Textfelder für die Bedienung des Taschenrechners angelegt. Die XAML-Syntax beschreibt, wie das UI aufgebaut ist.

### 4. Logik anpassen

Im Code-Behind (`MainWindow.xaml.cs`) wird festgelegt, was passiert, wenn z.B. auf einen Button geklickt wird. Hier wird das eigentliche Rechnen ausgeführt.

### 5. Eigenes Experimentieren

Versuche, weitere Funktionen einzubauen (zum Beispiel Prozentrechnung, Kommazahlen, etc.) oder das Design zu verändern.

## Weitere Ressourcen

- [Microsoft WPF Dokumentation (deutsch)](https://learn.microsoft.com/de-de/dotnet/desktop/wpf/)
- [YouTube: Einstieg in WPF](https://www.youtube.com/results?search_query=wpf+einstieg)

---

Viel Spaß beim Lernen und Ausprobieren!