import axios from 'axios'; 
 
const baseUrl = 'https://localhost:44384/api/AddressCodes/ ';
 
export const dbService = { 
    getAllAddressCode,      
    getAddressCodeById,     
    createAddressCode, 
    updateAddressCode, 
    deleteAddressCode 
}; 
 
 
function getAllAddressCode(){   
    return axios.get(baseUrl); 
} 
 
function getAddressCodeById(id){ 
    return axios.get(baseUrl + id); 
} 
 
function createAddressCode(AddressCodeObj){ 
    return axios.post(baseUrl, AddressCodeObj); 
} 
 
 
function updateAddressCode(id, AddressCodeObj){ 
    alert(id); 
    return axios.put(baseUrl+id, AddressCodeObj); 
} 
 
function deleteAddressCode(id){ 
    return axios.delete(baseUrl + id); 
} 
 
export default dbService;