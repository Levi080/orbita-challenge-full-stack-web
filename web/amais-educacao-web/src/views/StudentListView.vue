<template>
  <v-container>
    <v-card class="pa-4">
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

        <v-col cols="12" md="2" class="d-flex justify-end">
          <v-btn color="primary" block @click="navigateToStudentForm">
            Cadastrar Aluno
          </v-btn>
        </v-col>

      </v-row>

      <v-divider class="my-4"></v-divider>

      <v-data-table :headers="headersOfTable" :items="students" :loading="loading" class="elevation-1">
      <template v-slot:[`item.actions`]="{ item }">
        <v-btn color="primary" class="mr-2" @click="editStudent(item)">
          Editar
        </v-btn>
        <v-btn color="error" @click="deleteStudent(item)">
          Excluir
        </v-btn>
      </template>
      </v-data-table>

      <v-alert v-if="error" type="error" class="mt-4">
        {{ error }}
      </v-alert>

    </v-card>
  </v-container>
</template>

<script setup>
import { useRouter } from 'vue-router';
import { onMounted } from 'vue';
import { useStudentStore } from '@/stores/studentStore';
import { storeToRefs } from 'pinia';

const router = useRouter();
const studentStore = useStudentStore();

const { students, loading, error } = storeToRefs(studentStore);

const headersOfTable = [
  { title: 'Registro Acadêmico', key: 'ra' },
  { title: 'Nome', key: 'name' },
  { title: 'CPF', key: 'cpf' }
  // { title: 'Ações', key: 'actions', sortable: false }
];

const navigateToStudentForm = () => {
  router.push({ name: 'StudentForm' });
};

onMounted(() => {
  studentStore.getStudentsList();
  console.log('CONTEUDO DO STATE:', students)
});

</script>

<style scoped></style>