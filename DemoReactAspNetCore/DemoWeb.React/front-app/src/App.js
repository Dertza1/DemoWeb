import './App.css';
import Login from './Pages/Login';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import List from './Pages/List';
import Edit from './Pages/Edit';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/main" element={<List />} />
        <Route path="/product" element={<Edit />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
