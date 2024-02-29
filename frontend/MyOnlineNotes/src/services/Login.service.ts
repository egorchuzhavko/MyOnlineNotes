import axios from 'axios';
import { baseUrl } from './Base.service';

export const LoginService = {
  async loginUser(userData: IUser) {
    try {
      const response = await axios.post(baseUrl + '/User/Login', userData, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      return response.status === 200 ? true : false;
    } catch (error) {
      if (axios.isAxiosError(error)) {
        return false;
      } else {
        return false;
      }
    }
  },

  async getUserByLogin(login: string) {
    try {
      const response = await axios.get(baseUrl + `/User/${login}`);
      return response.data;
    } catch (error) {
      if (axios.isAxiosError(error)) {
        return false;
      } else {
        return false;
      }
    }
  },
};
