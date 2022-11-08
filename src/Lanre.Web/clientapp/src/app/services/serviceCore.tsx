
import axios, { AxiosResponse } from 'axios';

const token = () =>{
	const key = Object.keys(sessionStorage).find(x => x.startsWith('oidc.user:'));
	if(key == null) return '';

	const auth =sessionStorage.getItem(key)
	if(auth == null) return;
	 return JSON.parse(auth)["access_token"] ?? '';

}
const config = {
	// baseURL: 'http://host.docker.internal:8080/api/',
	// baseURL: 'https://localhost:7043/api/',
	// baseURL: '/api/',
	baseUrl: window.location.origin,
	timeout: 15000,
	headers: {
		'Content-Type': 'application/json',
		'Authorization': `Bearer ${token()}`
		// 'X-Requested-With': 'XMLHttpRequest',
	},

	// withCredentials: true
};

const selfWindow: Window = window;

export const Instance = axios.create(config);

Instance.interceptors.response.use((response) => {
	return response;
}, (error) => { // Anything except 2XX goes to here
	const status = error.response?.status || 500;
	if (status === 401) {
		selfWindow.location = window.location.protocol + "//" + window.location.host + "/sign-in";
	} else {
		return Promise.reject(error); // Delegate error to calling side
	}
});

export const responseBody = (response: AxiosResponse) => response.data;

export const Requests = {
	get: (url: string) => Instance.get(url).then(responseBody),
	post: (url: string, o: any) => Instance.post(url, JSON.stringify(o)).then(responseBody),
	put: (url: string, o: any) => Instance.put(url, JSON.stringify(o)).then(responseBody),
	delete: (url: string, o: any) => Instance.delete(url).then(responseBody),
};


