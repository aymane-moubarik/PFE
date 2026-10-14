# Analyseur cérébral

![Logo du projet](app/brain_logo.png)

Application de bureau réalisée avec **Python** et **Kivy** dans le cadre d'un projet de fin d'études. Elle propose une interface pour analyser des images médicales cérébrales avec des modèles d'apprentissage profond.

> **Avertissement médical :** ce projet est expérimental et fourni à des fins éducatives. Ses résultats ne constituent pas un diagnostic et ne doivent pas servir à prendre une décision médicale. Consultez un professionnel de santé.

## Fonctionnalités

L'application permet de sélectionner une image (`.png`, `.jpg` ou `.jpeg`), de choisir un modèle lorsqu'une option est proposée, puis de lancer une analyse. Les écrans couvrent :

| Écran | Modèles proposés dans l'interface |
| --- | --- |
| Autisme | GCN |
| Alzheimer | CNN, ViT |
| AVC | CNN |
| Sclérose en plaques (SEP) | CNN, U-Net |
| Parkinson | VGG19 |
| Tumeur cérébrale | U-Net |

L'interface affiche également des informations générales sur les maladies et les modèles. Les modèles sont chargés localement ; aucune API externe n'est utilisée pour l'analyse.

## Structure du projet

```text
PFE-main/
├── README.md
└── app/
    ├── main.py                # Démarrage de l'application Kivy
    ├── style_new.kv           # Interface graphique
    ├── config.py              # Informations sur les maladies et modèles
    ├── models.py              # Architectures et chargement des poids
    ├── brain_logo.png
    ├── models/                # Fichiers de poids des modèles
    ├── screens/               # Écrans de l'application
    └── utils/
        └── preprocessing.py   # Prétraitement des images
```

## Prérequis

- Python et `pip`.
- Les dépendances Python suivantes : `kivy`, `tensorflow`, `numpy`, `Pillow`, `torch`, `torchvision`, `torch-geometric` et `timm`.
- Les fichiers de poids attendus dans `app/models/` (voir la section suivante).

Les versions de TensorFlow, PyTorch, TorchVision et PyTorch Geometric doivent être compatibles entre elles et avec votre version de Python et votre système d'exploitation. Consultez leurs instructions d'installation officielles si l'installation générique ci-dessous échoue.

## Installation et lancement

Depuis la racine du projet, dans PowerShell sous Windows :

```powershell
py -m venv .venv
.\.venv\Scripts\Activate.ps1
python -m pip install --upgrade pip
python -m pip install kivy tensorflow numpy pillow torch torchvision torch-geometric timm
Set-Location app
python main.py
```

Le lancement depuis le dossier `app` est nécessaire : l'application charge `style_new.kv` et les poids des modèles avec des chemins relatifs à ce dossier.

## Fichiers de modèles requis

Au démarrage, `app/models.py` charge les fichiers suivants depuis `app/models/` :

| Fichier attendu | Présent dans le dépôt |
| --- | --- |
| `Alzheimer_CNN.h5` | Oui |
| `vit_Alzheimer.pth` | Non |
| `stroke_model.h5` | Non |
| `CNN_MS.h5` | Oui |
| `unet_MS.h5` | Non |
| `Brain_Tumor_U-NET.h5` | Non |
| `parkinson.pth` | Non |
| `autism_GCN.pth` | Non |

Les fichiers manquants doivent être obtenus depuis la source des modèles du projet et placés dans `app/models/` avant le lancement. Ils ne sont pas générés par l'application. Sans eux, le chargement des modèles peut interrompre le démarrage.

## Notes

- Les images sélectionnées sont prétraitées localement avant leur passage au modèle.
- L'application ne contient pas de commande d'entraînement des modèles.
- Aucun fichier `requirements.txt` n'est fourni pour le moment ; les dépendances sont donc listées dans ce README.
