import { loginEndpoint, registerEndpoint } from "../../endpoints/endpoints";
import { httpService } from "../../utils/httpService";

export interface loginRequest {
  email: string;
  password: string;
}

export interface registerRequest {
  fullName: string;
  email: string;
  phoneNumber: string;
  password: string;
}

export async function loginUser(loginDetails:loginRequest) {
   try{
      const result = await httpService.post(loginEndpoint, loginDetails);
      return result;
   }
   catch(error){
      console.error('failed to login', error)
      throw error; // rethrow if you want the caller to handle it
   }
}

export async function registerUser(registerDetails:registerRequest) {
   try{
      const result = await httpService.post(registerEndpoint, registerDetails);
      return result;
   }
   catch(error){
      console.error('failed to register user', error)
      throw error; // rethrow if you want the caller to handle it
   }
}