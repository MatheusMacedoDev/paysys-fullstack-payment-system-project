'use client';

import { Table } from '@/app/signed/components/Table';
import Form from '@/components/Form';
import { FormProvider } from 'react-hook-form';

import {
    UserTypeData,
    useUserTypeForm
} from '@/validations/userTypeValidations';

export default function UserTypePage() {
    const userTypeForm = useUserTypeForm();

    const { handleSubmit } = userTypeForm;

    function createUserType(data: UserTypeData) {
        console.log(data);
    }

    return (
        <>
            <section className="w-full py-24 flex items-center justify-center">
                <FormProvider {...userTypeForm}>
                    <Form.Container
                        onSubmit={handleSubmit(createUserType)}
                        sendButtonTitle="Cadastrar"
                    >
                        <Form.Title>Tipos de Usuários</Form.Title>
                        <Form.InputsGroup>
                            <Form.Input placeholder="Nome" name="name" />
                        </Form.InputsGroup>
                    </Form.Container>
                </FormProvider>
            </section>
            <Table.DarkBackground>
                <Table.Title>Lista de Tipos de Usuários</Table.Title>
                <Table.Container>
                    <Table.Header>
                        <Table.HeaderItem>Nome</Table.HeaderItem>
                        <Table.HeaderItem colSpan={2}>Ações</Table.HeaderItem>
                    </Table.Header>
                    <Table.DataBody>
                        <Table.Data>
                            <Table.DataItem>Comum</Table.DataItem>
                            <Table.DataItem>Comum</Table.DataItem>
                            <Table.DataItem>Comum</Table.DataItem>
                        </Table.Data>
                    </Table.DataBody>
                </Table.Container>
            </Table.DarkBackground>
        </>
    );
}
