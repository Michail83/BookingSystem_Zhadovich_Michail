import { tryLoadAuthData } from "./tryLoadAuthData";

export const unAuthorizedHandler = async (status) => {           
        if (status == 401) tryLoadAuthData();         
}