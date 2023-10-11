import logo from './logo.svg';
import './App.css';
import HeaderPage from './main/client/main';
import {
  BrowserRouter as Router,
  Route,
  Routes
} from "react-router-dom";

import Detail from './main/client/detail';
import CheckOut from './main/client/checkout';
import Cart from './main/client/cart';
import Category from './main/client/category';
import Login from './main/client/login';
import Admin from './main/client/admin';
import User from './main/client/user';

function App() {
  let obj = {};
  if(localStorage.getItem("info")!=null){
    let result = JSON.parse(localStorage.getItem("info"));
    obj.name = result.name;
    obj.role = result.role;
  }
  return (
    <Router>
      <Routes>
            {/* <Route path="/" element={<HeaderPage />} exact />
            <Route path="/detail/:id" element={<Detail />} exact />
            <Route path="/check-out" element={<CheckOut />} exact />
            <Route path="/cart" element={<Cart />} exact />
            <Route path="/category/:id" element={<Category />} exact /> */}
            <Route path="/login" element={<Login />} exact />
            <Route path="/admin" element={<Admin />} exact />
            <Route path="/user" element={<User />} exact />
      </Routes>
    </Router>
  );
}

export default App;
