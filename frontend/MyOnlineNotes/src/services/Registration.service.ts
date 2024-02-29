import axios from 'axios';
import { baseUrl } from './Base.service';

export const RegistrationService = {
  async registerUser(userData: IUser) {
    try {
      const response = await axios.post(baseUrl + '/User', userData, {
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
};
