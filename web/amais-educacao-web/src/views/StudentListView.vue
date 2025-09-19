<template>
  <v-container>
    <v-card class="pa-4 px-10">
      <v-card-title class="headline">
        Consulta de Alunos
      </v-card-title>
      <v-row class="mt-4" align="center">

        <v-col cols="12" md="6">
          <v-text-field label="Pesquise por aluno" outlined dense hide-details>

            <template v-slot:append-inner>
              <v-btn color="primary" class="ml-2">
                Pesquisar
              </v-btn>
            </template>

          </v-text-field>
        </v-col>

        <v-col class="d-flex">
          <v-spacer></v-spacer>
          <v-btn color="primary" @click="navigateToStudentForm">
            <v-icon left>mdi-plus</v-icon>
            Cadastrar Aluno
          </v-btn>
        </v-col>

      </v-row>

      <v-divider class="my-4"></v-divider>

      <v-data-table :headers="headersOfTable" :items="studentStore.students" :loading="studentStore.loading"
        class="elevation-1">
        <template v-slot:[`item.actions`]="{ item }">
          <v-btn icon="mdi-pencil" size="small" color="primary" class="mr-2" @click="editStudent(item)"> </v-btn>
          <v-btn icon="mdi-delete" size="small" color="error" @click="showConfirmDialog(item)"> </v-btn>
        </template>
      </v-data-table>

      <v-alert v-if="studentStore.error" type="error" class="mt-4">
        {{ studentStore.error }}
      </v-alert>
    </v-card>

    <ConfirmDialog ref="confirmDialog" title="Confirmação de Exclusão" :message="dialogMessage"
      @confirm="deleteStudent" />
  </v-container>
</template>

<script setup>
import { useRouter } from 'vue-router';
import { ref, onMounted } from 'vue';
import { useStudentStore } from '@/stores/studentStore';
import ConfirmDialog from '@/components/ConfirmDialog.vue';

const router = useRouter();
const studentStore = useStudentStore();
const confirmDialog = ref(null);
const dialogMessage = ref('');

const headersOfTable = [
  { title: 'Registro Acadêmico', key: 'ra' },
  { title: 'Nome', key: 'name' },
  { title: 'CPF', key: 'cpf' },
  { title: 'Ações', key: 'actions', sortable: false, align: 'center' }
];

const navigateToStudentForm = () => {
  router.push({ name: 'StudentForm' });
};

onMounted(() => {
  studentStore.getStudentsList();
});

const editStudent = (student) => {
  studentStore.setStudentSelected(student)
  router.push({ name: 'StudentForm' });
};

const showConfirmDialog = (student) => {
  dialogMessage.value = `Tem certeza que deseja excluir o aluno ${student.name}?`;
  confirmDialog.value.open(student);
};

const deleteStudent = async (student) => {
  await studentStore.deleteStudent(student.ra);
};

</script>

<style scoped></style>