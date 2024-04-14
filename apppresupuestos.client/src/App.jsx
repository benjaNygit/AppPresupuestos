import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [budgetAccount, setBudgetAccount] = useState();

    useEffect(() => {
        getBudgetAccount();
    }, []);

    const showBudgetAccount = budgetAccount === undefined ? <p>No hay conexión con la base de datos</p> :
        <table>
            <thead>
                <tr>
                    <th>Descripción</th>
                    <th>Nivel</th>
                    <th>Número de cuenta</th>
                </tr>
            </thead>
            <tbody>
                {budgetAccount.map(item =>
                    <tr key={item.numberAccount}>
                        <td>{item.description}</td>
                        <td>{item.level}</td>
                        <td>{item.numberAccount}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1>Cuentas Presupuestarias</h1>
            {showBudgetAccount}
        </div>
    );
    
    async function getBudgetAccount() {
        const response = await fetch('/api/BudgetAccount');
        const data = await response.json();
        setBudgetAccount(data);
    }
}

export default App;