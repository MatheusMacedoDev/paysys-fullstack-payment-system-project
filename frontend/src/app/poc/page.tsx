'use client';

import Footer from '@/components/Footer';
import Form from '@/components/Form';
import SelectItemModel from '@/components/Form/Select/SelectItemModel';
import Header from '@/components/Header';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import { useState } from 'react';

export default function pocPage() {
    // eslint-disable-next-line react-hooks/rules-of-hooks
    const [selectedItem, setSelectedItem] = useState<SelectItemModel>();

    return (
        <div className="w-screen h-screen">
            <Header />

            <Form.Background>
                <Form.Container sendButtonTitle="Ação">
                    <Form.Title>Formulário</Form.Title>
                    <Form.InputsGroup>
                        <Form.Select
                            placeholder="Selecione..."
                            value={selectedItem!}
                            onChange={setSelectedItem}
                            data={[
                                { value: '1', displayText: 'Opção 1' },
                                { value: '2', displayText: 'Opção 2' }
                            ]}
                        />
                        <Form.Input placeholder="Input 1" icon={faUser} />
                        <Form.SplitedGroup>
                            <Form.Input placeholder="Input 2" />
                            <Form.Input placeholder="Input 3" />
                        </Form.SplitedGroup>
                    </Form.InputsGroup>
                </Form.Container>
            </Form.Background>

            <Footer />
        </div>
    );
}
