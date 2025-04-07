import { createRoot } from 'react-dom/client'
import './index.css'
import HomePage from './Views/HomePage/HomePage.jsx'
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import LogInPage from './Views/LogInPage/LogInPage.jsx';
import SignInPage from './Views/SignInPage/SignInPage.jsx';
createRoot(document.getElementById('root')).render(
  <Router>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/login" element={<LogInPage />} />
                <Route path="/signup" element={<SignInPage />} />
            </Routes>
  </Router>
)
