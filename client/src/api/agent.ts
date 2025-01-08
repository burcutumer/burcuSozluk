import axios, { AxiosResponse } from "axios";

axios.defaults.baseURL = "http://localhost:5101/api/";


axios.interceptors.request.use(
    (config) => {
        const token = localStorage.getItem('jwt');
        if (token) {
            config.headers.Authorization = `Bearer ${token}`;
        }
        return config
    },
    (error) => {
        return Promise.reject(error);
    }
)

const responseBody = (response: AxiosResponse) => response.data;

const requests = {
  get: (url: string) => axios.get(url).then(responseBody),
  post: (url: string, body: {}) => axios.post(url, body).then(responseBody),
  delete: (url: string) => axios.delete(url).then(responseBody),
};

const Entries = {
  list: () => requests.get("Entry?skip=0&limit=3"),
  details: (id:number) => requests.get(`Entry/${id}`)
};

const Comments = {
  add: (entryId: number, values: any) => requests.post(`comment/${entryId}`,values),
  list: (entryId: number) => requests.get(`comment/${entryId}?skip=0&limit=3`)
}
const Tags = {
  list: () => requests.get("tags?skip=0&limit=3"),
};

const Account = {
    login: (values: any) => requests.post('auth',values),
    regsiter: (values: any) => requests.post('user',values),
    currentUser: () => requests.get('user')
};

const agent = {
  Entries,
  Tags,
  Account,
  Comments
};
export default agent;
