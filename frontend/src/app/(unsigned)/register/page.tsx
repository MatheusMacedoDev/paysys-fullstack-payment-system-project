'use client';

import Form from '@/components/Form';
import SelectItemModel from '@/components/Form/Select/SelectItemModel';
import { faEnvelope, faKey, faPhone } from '@fortawesome/free-solid-svg-icons';
import { useEffect, useState } from 'react';

enum UserType {
    CommonUser = 0,
    ShopkeeperUser = 1
}

export default function Register() {
    const [selectedUserType, setSelectedUserType] = useState<UserType>();

    useEffect(() => {
        console.log(JSON.stringify(selectedUserType));
    }, [selectedUserType]);

    function selectUserType(selectedItem: SelectItemModel) {
        const value = selectedItem.value;
        const userType: UserType = value;

        setSelectedUserType(userType);
    }

    return (
        <Form.Background>
            <Form.Container sendButtonTitle="Registrar">
                <Form.Title>Registre-se</Form.Title>
                <Form.InputsGroup>
                    <Form.Select
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
                            <Form.Input placeholder="Nome" />
                            <Form.Input placeholder="CPF" />
                        </Form.SplitedGroup>
                    )}

                    {selectedUserType === UserType.ShopkeeperUser && (
                        <>
                            <Form.SplitedGroup>
                                <Form.Input placeholder="Nome Fantasia" />
                                <Form.Input placeholder="Razão Social" />
                            </Form.SplitedGroup>
                            <Form.Input placeholder="CNPJ" />
                        </>
                    )}

                    <Form.Input placeholder="E-mail" icon={faEnvelope} />
                    <Form.Input placeholder="Telefone" icon={faPhone} />
                    <Form.SplitedGroup>
                        <Form.Input placeholder="Senha" icon={faKey} />
                        <Form.Input
                            placeholder="Confirmar Senha"
                            icon={faKey}
                        />
                    </Form.SplitedGroup>
                </Form.InputsGroup>
            </Form.Container>
        </Form.Background>
    );
}
