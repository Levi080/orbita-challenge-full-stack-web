import { defineStore } from 'pinia';
import axios from 'axios';

export const useStudentStore = defineStore('student', {
  state: () => ({
    students: [],
    loading: false,
    error: null,
  }),
  actions: {
    async getStudentsList() {
      this.loading = true;
      this.error = null;
      try {
        const response = await axios.get(`${process.env.VUE_APP_API_URL}/Student/GetStudentsList`);
        console.log('CONTEUDO DA RESPONSE:', response.data)
        this.students = response.data;
      } catch (error) {
        this.error = 'Ocorreu um erro ao buscar os alunos.';
        console.error(error);
      } finally {
        this.loading = false;
      }
    },
    async createStudent(student) {
      this.loading = true;
      this.error = null;
      try {
        await axios.post(`${process.env.VUE_APP_API_URL}/Student/CreateStudent`, student);
        await this.getStudentsList(); 
      } catch (error) {
        this.error = 'Ocorreu um erro ao criar o aluno.';
        console.error(error);
      } finally {
        this.loading = false;
      }
    },
    async updateStudent(student) {
      this.loading = true;
      this.error = null;
      try {
        await axios.put(`${process.env.VUE_APP_API_URL}/Student/UpdateStudent`, student);
        await this.getStudentsList();
      } catch (error) {
        this.error = 'Ocorreu um erro ao atualizar o aluno.';
        console.error(error);
      } finally {
        this.loading = false;
      }
    },
    async deleteStudent(ra) {
      this.loading = true;
      this.error = null;
      try {
        await axios.delete(`${process.env.VUE_APP_API_URL}/Student/DeleteStudent?ra=${ra}`);
        await this.getStudentsList();
      } catch (error) {
        this.error = 'Ocorreu um erro ao excluir o aluno.';
        console.error(error);
      } finally {
        this.loading = false;
      }
    },
  },
});