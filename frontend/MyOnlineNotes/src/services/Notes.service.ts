import axios from 'axios';
import { baseUrl } from './Base.service';

export const NotesService = {
  async takeUserNotes(userId: string) {
    try {
      const response = await axios.get(baseUrl + `/Note/${userId}`);
      return response.data;
    } catch (error) {
      if (axios.isAxiosError(error)) {
        return false;
      } else {
        return false;
      }
    }
  },

  async createNewNote(note: INoteRequest) {
    try {
      const response = await axios.post(baseUrl + '/Note', note, {
        headers: {
          'Content-Type': 'application/json',
        },
      });
      return response.status === 200 ? response.data : '';
    } catch (error) {
      if (axios.isAxiosError(error)) {
        return '';
      } else {
        return '';
      }
    }
  },

  async updateNote(userId: string, note: INoteRequest) {
    try {
      const response = await axios.put(baseUrl + `/Note/${userId}`, note, {
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

  async deleteNote(noteId: string) {
    try {
      const response = await axios.delete(baseUrl + `/Note/${noteId}`, {
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
