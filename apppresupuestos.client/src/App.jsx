import './App.css';

import { Routes, Route } from 'react-router-dom'
import Layout from './Components/Layout'
import Home from './Pages/Home'
import BudgetAccount from './Pages/BudgetAccount'
import Default from './Pages/Default'

function App() {
    return (
        <>
            <Routes>
                <Route path='/' element={ <Layout /> }>
                    <Route path='/' element={ <Home /> } />
                    <Route path='/budgetAccount' element={<BudgetAccount /> } />
                    <Route path='/*' element={<Default /> } />
                </Route>
            </Routes>
        </>
    )
}

export default App;