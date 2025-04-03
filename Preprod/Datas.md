User :
	Nom : string
	Prénom: string
	Mot de passe (crypté) : string
	Photo : string?
	Email : string
	Téléphone : string
	Review[]? : Review
	IsAdmin : bool
	Voyage[]? : Voyage
	Historique[]? : Voyage
	IsVerified? : bool
	Conducteur? : Conducteur

Conducteur :
	User : User
	Voiture : Voiture

Voiture :
	Modèle : string
	Capacité : int
	Couleur : string
	Volume : float
	Plaque : string
	Conducteur : Conducteur
	

Voyage :
	IsAvailable : bool
	Etapes[] : Etapes
	Conducteur : Conducteur
	Passagers[] : User
	Prix : double
	Durée : TimeSpan

Etape :
	Adresse : string (API)
	DateHeure : DateTime
	Voyage : Voyage

Review :
	Commentaire : string
	Note : int
	UserFrom : User

---

API google maps



------------------

UML : https://dbdiagram.io/d/CoVoyageurM2i-67ee9f0e4f7afba1843fb309