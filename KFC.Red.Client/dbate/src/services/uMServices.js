    
import axios from "axios";

let config = {
  headers: {
    Token: localStorage.getItem("token")
  }
};

const GetUser = () =>
{
    config.headers.Token = localStorage.getItem("token");
    return axios.get('http://localhost:5000/api/user/getuser', config)
        .then(response =>
        {
            return response;
        })
}

export
{
    GetUser
}