import axios from 'axios'

//'http://localhost:xxxx/'
export const BASE_URL = 'http://localhost:5000/';

export const ENDPOINT ={
    category: 'Category',
    product: 'Product',
    provider: 'Provider'
}

export const createAPIEndpoint = endpoint => {

    let url = BASE_URL + 'api/' + endpoint + '/';

    return {
        fetch: () => axios.get(url),
        fetchById: id => axios.get(url + id),
        post: newRecord => axios.post(url, newRecord),
        put: (id, updatedRecord) => axios.put(url + id, updatedRecord),
        delete: id => axios.delete(url + id),
    }

}