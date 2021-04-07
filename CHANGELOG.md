# Changelog
Toutes les modifications notables apportées à ce projet seront documentées dans ce dossier.

Le format est basé sur [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
et ce projet s'inscrit dans [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.3] - 2021-04-07
### Ajouté
- Scenes :
  - Ajout de la scene sélection du personnage 
- Sons :
  - Ajout musique pour la scene de démarrage du jeu
  - Ajout musique pour la scene de victoire de la partie
  - Ajout deux musiques pour la scene affrontement
  - Ajout de bruitage pour les attaques de bases et spéciales des personnages
  - Ajout bruitage pour la mort d'un joueur
  - Ajout bruitage lors des dégats
  - Ajout bruitage pour la récupération d'un objet
  - Ajout bruitage lors réapparition d'un joueur
- Joueurs :
  - Ajout attaque special du personnage Spectre
  - Ajout animation attaque spéciale de Spectre
  - Ajout d'un nouveau personnage : Cap Oil
    - Ajout design du personage  
    - Ajout de son attaque de base : Coup de tentacule
    - Ajout de l'animation pour l'attaque de base
    - Ajout de son attaque spécial : Rayon laser
  - Ramassage et utilisation des objets
- UI :
  - Ajout icônes pour les joueurs
  - Ajout icônes pour attaque de base et special pour chaque personnage
  - Ajout emplacement pour l'icône état (brûlure) du joueur
  - Ajout background pour affichage phase
  - Ajout background pour affichage chrono de la phase
  - Ajout animation cooldown :
    - Attaque de base
    - Attaque spéciale
- Technique :
  - Ajout principe de phase
  - Ajout phase modification de la map :
    - Ajout phase "terres brulées"
  - Ajout échange d'informations entre scenes
  - Ajout changement sprite lors déplacement personages
  - Ajout principe de cooldown :
    - Ajout cooldown lors des attaques de bases et spéciales

### Modifications
- Graphique :
  - Redesign background de scenes :
    - Scene menu démarage
    - Scene victoire
  - Modification sprite attaque de base Spectre
  - Nouveau design pour un des obstacles internes
  - Nouveau design du logo du jeu
- Technique :
  - Rassemblement des touches dans un même script

### Correction de bugs
- Technique :
  - Correction bug lors du lancement de l'attaque de base de Spectre : n'envoi plus plusieurs attaques

## [0.2] - 2021-01-06
### Ajouté
- Map :
  - Ajout de plusieurs zone de respawn pour les joueurs
- Scene :
  - Ajout d'un background pour la scene de jeu
  - Ajout de la scene de codex
  - Ajout de la scene de configuration
- UI (scene de jeu) :
  - Ajout d'un background pour les joueurs
- Joueurs :
  - Ajout de la fonctionnalité de respawn

### Modification
- UI :
  - Réorganisation des composants
- Map :
  - Refonte graphique de la map :
    - Réagencement de la map
    - Nouvelle structure pour le terrain
    - Nouveau design des obstacles
    - Nouveau design avec changement de la taille des limites du terrain
    - Nouveau design des terrains

### Correction de bug
- UI :
  - Correction de la synchronisation entre UI back-end et UI front-end

## [0.1] - 2020-11-25
### Ajouté
- Personnages :
  - Modelisation du personnage "Spectre"
  - Déplacement des personnages sur 2 axes
  - Apparition de deux personnages sur le terrain
  - Attaque de base pour les personnages
  - Les personnages peuvent subir des dégats
- Objets :
  - Modelisation des soins :
    - Modelisation de la potion faible
    - Modelisation de la potion moyenne
    - Modelisation de la potion forte
  - Modelisation des armures :
    - Modelisation de l'armure faible
    - Modelisation de l'armure moyenne
    - Modelisation de l'armure forte
- Map :
  - Modelisation et affichage de la map :
    - Ajout de trois sols différents
    - Ajout de l'obstacle délimitant la map
    - Ajout de trois obstacles:
      - Ajout de l'obstacle "arbre"
      - Ajout de l'obstacle "champignon"
      - Ajout de l'obstacle "rocher"
  - Apparition des objets soins et armures sur la map
- UI :
  - Affichage du nom du personnage
  - Affichage de la barre de vie
  - Modelisation et affichage des points de réapparition
  - Affichage d'un chronometre (non fonctionnel)
  - Affichage de la barre d'armure
  - Affichage d'indication :
    - Affichage du cooldown de l'attaque de base/attaque sépciale (non fonctionnel)
    - Affichage nombre de réutilisation de l'objet (non fonctionnel)
    - Affichage de la description de l'objet ramassé
  - Affichage des commandes du jeu
  - Affichage de la phase en cours (non fonctionnel)
  - Modelisation et affichage du slot pour l'attaque de base/attaque sépciale
  - Modelisation et affichage du slot de l'objet ramassé (non fonctionnel)
- Scene :
  - Création de la scene de démarrage du jeu
  - Creation de la scene de la map d'affrontement
  - Ajout d'un freeze avant début du combat pour la scene de la map d'affrontement
  - Création de la scene de victoire de la partie
