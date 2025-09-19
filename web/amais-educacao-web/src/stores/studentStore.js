import { defineStore } from "pinia";
import axios from "axios";

export const useStudentStore = defineStore("student", {
  state: () => ({
    students: [],
    studentSelected: null,
    loading: false,
    error: null,

    toast: {
      show: false,
      message: "",
      color: "",
    },
  }),
  actions: {
    showToast(message, color) {
      this.toast.show = true;
      this.toast.message = message;
      this.toast.color = color;
    },

    async getStudentsList() {
      this.loading = true;
      this.error = null;
      try {
        const response = await axios.get(
          `${process.env.VUE_APP_API_URL}/Student/GetStudentsList`
        );
        this.students = response.data;
      } catch (error) {
        this.error = `Ocorreu um erro ao buscar os alunos:${error}`;
      } finally {
        this.loading = false;
      }
    },
    async createStudent(student) {
      this.loading = true;
      this.error = null;
      try {
        await axios.post(
          `${process.env.VUE_APP_API_URL}/Student/CreateStudent`,
          student
        );
        await this.getStudentsList();
        this.showToast("Aluno cadastrado com sucesso!", "success");
      } catch (error) {
        this.error = "Ocorreu um erro ao criar o aluno.";
        this.showToast(this.error, "error");
      } finally {
        this.loading = false;
      }
    },
    async updateStudent(student) {
      this.loading = true;
      this.error = null;
      try {
        await axios.put(
          `${process.env.VUE_APP_API_URL}/Student/UpdateStudent`,
          student
        );
        await this.getStudentsList();
        this.showToast("Aluno atualizado com sucesso!", "success");
      } catch (error) {
        this.error = "Ocorreu um erro ao atualizar o aluno.";
        this.showToast(this.error, "error");
      } finally {
        this.loading = false;
      }
    },
    async deleteStudent(ra) {
      this.loading = true;
      this.error = null;
      try {
        await axios.delete(
          `${process.env.VUE_APP_API_URL}/Student/DeleteStudent?ra=${ra}`
        );
        await this.getStudentsList();
        this.showToast("Aluno excluído com sucesso!", "success");
      } catch (error) {
        this.error = "Ocorreu um erro ao excluir o aluno.";
        this.showToast(this.error, "error");
      } finally {
        this.loading = false;
      }
    },
    setStudentSelected(student) {
      this.studentSelected = student;
    },
  },
});
