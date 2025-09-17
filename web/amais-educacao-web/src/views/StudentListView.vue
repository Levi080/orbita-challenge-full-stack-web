<template>
    <v-container>
      <v-card class="pa-4">
        <v-card-title class="headline">
          Consulta de Alunos
        </v-card-title>
        <v-row class="mt-4" align="center">

          <v-col cols="12" md="6">
            <v-text-field
              label="Pesquise por aluno"
              outlined
              dense
              hide-details
            >
        
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
  
        </v-card>
    </v-container>
  </template>
  
  <script setup>
  import { useRouter } from 'vue-router';
  
  const router = useRouter();
  
  const navigateToStudentForm = () => {
    router.push({ name: 'StudentForm' });
  };
  </script>
  
  <style scoped>

  </style>