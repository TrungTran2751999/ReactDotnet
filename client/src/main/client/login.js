import axios from "axios";
import { useState } from "react";
import port from "../../util/util";
import {setCookie,getCookie,eraseCookie} from "../../util/utilfunc";
import jwtDecode from "jwt-decode";
function Login(){
    let direct = {
        "ADMIN":"admin",
        "USER":"user",
    }
    if(localStorage.getItem("info")!=null){
        let obj = JSON.parse(localStorage.getItem("info"));
        let code = jwtDecode(obj.jwt);
        
        for(let item of Object.keys(direct)){
            if(code.role == item){
                window.location.href = `/${direct[item]}`;
                break;
            }
        }
    }
    const [login, setLogin] = useState({username:"",password:""});
    function handleChange(event){
        const {name, value} = event.target;
        setLogin((prevState)=>({
            ...prevState,
            [name]:value
        })
        )
    }
    function handleSubmit(){
        axios.post(port + "/api/login",login)
        .then((res)=>{
            setCookie("token",res.data.securitykey);
            localStorage.setItem("info",JSON.stringify({user: res.data.username, role: res.data.role, jwt: res.data.securitykey}));
            let code = jwtDecode(res.data.securitykey);
            for(let item of Object.keys(direct)){
                if(code.role == item){
                    window.location.href = `/${direct[item]}`;
                    break;
                }
            }
        })
        .catch((err)=>{
            console.log(err);
        })
    }
    return (
        <>
            <input type="text" name="username" value={login.username} onChange={handleChange}/>
            <input type="text" name="password" value={login.password} onChange={handleChange}/>
            <button onClick={handleSubmit}>SUBMIT</button>
        </>
    )
}
export default Login;