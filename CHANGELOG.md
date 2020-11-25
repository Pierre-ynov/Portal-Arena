# Changelog
Toutes les modifications notables apportées à ce projet seront documentées dans ce dossier.

Le format est basé sur [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
et ce projet s'inscrit dans [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

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
  - Modelisation et affichage des points de réaparrition
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
