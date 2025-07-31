# Stock & Présence App

Ce projet contient :
- **BackendApi** : API ASP.NET Core Web API pour la gestion des stocks, présences, utilisateurs, etc.
- **MobileApp** : Application mobile (prévue pour .NET MAUI, à installer dès que le template sera disponible sur votre SDK).

## Fonctionnalités prévues
- Authentification par empreinte digitale
- Géolocalisation
- Scan de produits (code-barres/QR)
- Notifications push
- Gestion de stock et de présence

## Démarrage rapide
1. Ouvrir le dossier dans VS Code
2. Backend : `cd BackendApi` puis `dotnet run`
3. (MobileApp : création possible dès que le template .NET MAUI est disponible sur votre SDK)

## Prérequis
- .NET SDK 10+ (Web API OK, MAUI nécessite un template compatible)
- Visual Studio 2022+ ou VS Code

## Notes
- Le template .NET MAUI n’est pas disponible dans votre SDK actuel. Installez-le pour activer la partie mobile.
- L’API backend fonctionne déjà (voir dossier BackendApi).
