const UserForm = () => {
    return (
        <>
            <form className="userform">
                <label for="username">Nom d'utilisateur:</label>
                <input type="text"></input>
                <label for="username">Email:</label>
                <input type="text"></input>
                <label for="username">Mot de passe:</label>
                <input type="text"></input>
                <label for="username">Téléphone:</label>
                <input type="number"></input>
                <button type="submit">Enregistrer</button>
            </form>
        </>
    )
}

export default UserForm