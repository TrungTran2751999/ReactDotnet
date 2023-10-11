import axios from "axios";
import { useState } from "react";
import port from "../../util/util";
import { authoriztion } from "../../util/utilfunc";


function Admin(){
    authoriztion("ADMIN");
    return (
        <>
            <p>ADMIN</p>
        </>
    )
}
export default Admin;