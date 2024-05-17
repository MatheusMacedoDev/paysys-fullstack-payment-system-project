'use client';

import Form from '@/components/Form';
import SelectItemModel from '@/components/Form/Select/SelectItemModel';
import { faEnvelope, faKey, faPhone } from '@fortawesome/free-solid-svg-icons';
import { useEffect, useState } from 'react';

export default function Register() {
    const [selectedUserType, setSelectedUserType] = useState<SelectItemModel>();

    useEffect(() => {
        console.log(JSON.stringify(selectedUserType));
    }, [selectedUserType]);

    return (
        <Form.Background>
            <Form.Container sendButtonTitle="Registrar">
                <Form.Title>Registre-se</Form.Title>
                <Form.InputsGroup>
                    <Form.Select
                        placeholder="Qual seu tipo de usuário?"
                        data={[
                            {
                                value: '1',
                                displayText: 'Comum'
                            },
                            {
                                value: '2',
                                displayText: 'Lojista'
                            }
                        ]}
                        value={selectedUserType!}
                        onChange={setSelectedUserType}
                    />

                    {selectedUserType?.displayText === 'Comum' && (
                        <Form.SplitedGroup>
                            <Form.Input placeholder="Nome" />
                            <Form.Input placeholder="CPF" />
                        </Form.SplitedGroup>
                    )}

                    {selectedUserType?.displayText === 'Lojista' && (
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
