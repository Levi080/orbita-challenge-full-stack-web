<template>
    <v-container>
        <v-card class="pa-4">
            <v-card-title class="headline">
                Cadastro de aluno
            </v-card-title>
            <v-form ref="form" v-model="valid" lazy-validation>
                <v-container>
                    <v-row>
                        <v-col cols="12">
                            <v-text-field v-model="student.name" label="Nome" placeholder="Informe o nome completo"
                                outlined dense required></v-text-field>
                        </v-col>
                        <v-col cols="12">
                            <v-text-field v-model="student.email" label="E-mail" placeholder="Informe apenas um e-mail"
                                outlined dense required></v-text-field>
                        </v-col>
                        <v-col cols="12">
                            <v-text-field v-model="student.ra" label="RA" placeholder="Informe o registro acadêmico"
                                outlined dense required></v-text-field>
                        </v-col>
                        <v-col cols="12">
                            <v-text-field v-model="student.cpf" label="CPF" placeholder="Informe o número do documento"
                                outlined dense required></v-text-field>
                        </v-col>
                    </v-row>
                </v-container>
            </v-form>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="red" @click="cancel" class="ml-2">
                    Cancelar
                </v-btn>
                <v-btn color="primary" @click="save" class="ml-2">
                    Salvar
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-container>
</template>

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';

const router = useRouter();
const student = ref({
    name: '',
    email: '',
    ra: '',
    cpf: ''
});

const cancel = () => {
    router.push({ name: 'StudentList' });
};

const save = () => {
    console.log('Dados do aluno:', student.value);
};
</script>