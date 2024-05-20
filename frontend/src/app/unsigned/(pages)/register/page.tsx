'use client';

import { faEnvelope, faKey, faPhone } from '@fortawesome/free-solid-svg-icons';
import Form from '@/components/Form';

import SelectItemModel from '@/components/Form/Select/SelectItemModel';

import {
    BaseRegisterData,
    CommonUserRegisterData,
    ShopkeeperRegisterData
} from '@/validations/registerValidations';

import { useEffect, useState } from 'react';
import { FormProvider } from 'react-hook-form';
import { useRegisterForm } from './useRegisterForm';

export enum UserType {
    CommonUser = 'CommonUser',
    ShopkeeperUser = 'ShopkeeperUser'
}

export default function Register() {
    const [selectedUserType, setSelectedUserType] = useState<UserType>();

    const registerForm = useRegisterForm(selectedUserType!);

    const {
        handleSubmit,
        getValues,
        formState: { errors }
    } = registerForm;

    useEffect(() => {
        console.log(errors);
        console.log(getValues());
    }, [errors, getValues]);

    function selectUserType(selectedItem: SelectItemModel) {
        const value = selectedItem.value;
        const userType: UserType = value as UserType;

        setSelectedUserType(userType);
    }

    function makeRegister(
        data: BaseRegisterData | CommonUserRegisterData | ShopkeeperRegisterData
    ) {
        console.log(data);
    }

    return (
        <Form.Background>
            <FormProvider {...registerForm}>
                <Form.Container
                    sendButtonTitle="Registrar"
                    onSubmit={handleSubmit(makeRegister)}
                >
                    <Form.Title>Registre-se</Form.Title>
                    <Form.InputsGroup>
                        <Form.Select
                            name="userType"
                            placeholder="Qual seu tipo de usuário?"
                            data={[
                                {
                                    value: UserType.CommonUser,
                                    displayText: 'Não sou um lojista'
                                },
                                {
                                    value: UserType.ShopkeeperUser,
                                    displayText: 'Sou um lojista'
                                }
                            ]}
                            onChange={selectUserType}
                        />

                        {selectedUserType === UserType.CommonUser && (
                            <Form.SplitedGroup>
                                <Form.Input name="name" placeholder="Nome" />
                                <Form.Input
                                    name="cpf"
                                    mask="999.999.999-99"
                                    placeholder="CPF"
                                />
                            </Form.SplitedGroup>
                        )}

                        {selectedUserType === UserType.ShopkeeperUser && (
                            <>
                                <Form.SplitedGroup>
                                    <Form.Input
                                        name="fancyName"
                                        placeholder="Nome Fantasia"
                                    />
                                    <Form.Input
                                        name="companyName"
                                        placeholder="Razão Social"
                                    />
                                </Form.SplitedGroup>
                                <Form.Input
                                    name="cnpj"
                                    mask="99.999.999/9999-99"
                                    placeholder="CNPJ"
                                />
                            </>
                        )}

                        <Form.Input
                            name="email"
                            placeholder="E-mail"
                            icon={faEnvelope}
                        />
                        <Form.Input
                            name="phoneNumber"
                            mask="(99) 99999-9999"
                            placeholder="Telefone"
                            icon={faPhone}
                        />
                        <Form.SplitedGroup>
                            <Form.Input
                                name="password"
                                placeholder="Senha"
                                icon={faKey}
                            />
                            <Form.Input
                                name="confirmPassword"
                                placeholder="Confirmar Senha"
                                icon={faKey}
                            />
                        </Form.SplitedGroup>
                    </Form.InputsGroup>
                </Form.Container>
            </FormProvider>
        </Form.Background>
    );
}
