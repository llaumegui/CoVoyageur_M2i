User :
	Pseudo
	Nom
	Prénom
	Mot de passe (crypté)
	Photo
	Email
	Téléphone
	Notes[]
	IsAdmin ?
	Trajets[]
	Historique[] : TrajetsId
	Conducteur

Conducteur :
	User 
	Voiture
	Profil vérifié ?

Trajet :
	Etapes[]
	Conducteur : Conducteur
	Passagers[] : User
	Prix

Etape :
	Adresse : string (API)
	Heure

Review :
	Commentaire : string
	Note : int

---

API google maps