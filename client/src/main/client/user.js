import axios from "axios";
import { useState } from "react";
import port from "../../util/util";
import { authoriztion } from "../../util/utilfunc";

function User(){
    authoriztion("USER");
    return (
        <>
            <p>User</p>
        </>
    )
}
export default User;