import { createRoot } from 'react-dom/client'
import './index.css'
import HomePage from './Views/HomePage/HomePage.jsx'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import LogInPage from './Views/LogInPage/LogInPage.jsx';
import SignInPage from './Views/SignInPage/SignInPage.jsx';
import SearchPage from './Views/SearchPage/SearchPage.jsx';
import ProfilePage from './Views/ProfilePage/ProfilePage.jsx';
import SearchTravelsPage from './Views/SearchTravelsPage/SearchTravelsPage.jsx';
createRoot(document.getElementById('root')).render(
  <Router>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/login" element={<LogInPage />} />
                <Route path="/signup" element={<SignInPage />} />
                <Route path="/search" element={<SearchPage />} />
                <Route path="/profile" element={<ProfilePage />} />
                <Route path="/search/travels" element={<SearchTravelsPage/>} />
                {/* <Route path="/profile/:id" element={<ProfilePage />} /> ROUTE DE L'UTILISATEUR PAR SON ID*/}
            </Routes>
  </Router>
)
