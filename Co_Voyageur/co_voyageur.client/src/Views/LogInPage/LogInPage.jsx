import React from 'react';

const LogInPage = () => {
    return (
        <div>
            <h1>Connexion</h1>
            <form>
                <div>
                    <label htmlFor="email">Email:</label>
                    <input type="email" id="email" name="email" required />
                </div>
                <div>
                    <label htmlFor="password">Password:</label>
                    <input type="password" id="password" name="password" required />
                </div>
                <button type="submit">Log In</button>
            </form>
        </div>
    );
};

export default LogInPage;