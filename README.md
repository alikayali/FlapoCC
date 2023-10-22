# FlapoCC
# Xamarin Code Challenge Repository - Biersortiments-App

## Projektbeschreibung
Dieses Repository enthält ein Beispielprojekt für die Xamarin Code Challenge.

## Systemanforderungen

Um dieses Projekt auszuführen und weiterzuentwickeln, benötigen Sie:

- Visual Studio mit Xamarin-Unterstützung.
- Android SDK Plattform 33.
- Windows 10 SDK (Version 10.0.19041.0).

## Projektstruktur

Das Projekt ist in Xamarin.Forms entwickelt und verfügt über die folgenden wichtigen Komponenten:

- **App**: Dieser Bereich enthält die Hauptanwendungslogik und die Navigationslogik Ihrer App.

- **Platforms**: Hier sind spezifische Xamarin-Plattformimplementierungen, die für die unterschiedlichen Betriebssysteme (win, Android, iOS) erforderlich sind.

- **Core**: In diesem Bereich sind die Kernkomponenten der App untergebracht, einschließlich Services, ViewModels, Constants und Extensions.
  - **Services**: Hier befinden sich Implementierungen für die Kommunikation mit dem Webdienst.
  - **ViewModels**: ViewModels, die die Logik und Datenverarbeitung für die Ansichten bereitstellen.
  - **Constants**: Dieser Ordner enthält Konstanten und Einstellungen.
  - **Extensions**: Hier können Erweiterungsmethoden und Hilfsfunktionen platziert werden.

- **Core.Data**: Dieser Bereich enthält Datenmodelle zur Darstellung von Produkten und Artikeln.

## Nutzung

Um das Projekt auszuführen, stellen Sie sicher, dass Sie die oben genannten Systemanforderungen erfüllen und die erforderlichen NuGet-Pakete installiert sind.

1. Klonen Sie dieses Repository auf Ihren Entwicklungscomputer.
2. Öffnen Sie die Projektdatei in Visual Studio.
3. Konfigurieren Sie Ihr Xamarin-Entwicklungsziel und starten Sie die App.

## Aufgaben und Erweiterungen

Dieses Projekt dient als Ausgangspunkt für die Code Challenge und enthält die grundlegenden Strukturen und Implementierungen. die folgenden Anforderungen sind erfüllt:

- Abruf und Anzeige von Produktdaten aus dem bereitgestellten Webdienst.
- Implementierten Sortierfunktion für die Artikelansicht.
- Detailansicht für Artikel, um zusätzliche Informationen anzuzeigen.
