'use client';

import Form from '@/components/Form';
import {
    MakePaymentData,
    makePaymentSchema
} from '@/validations/makePaymentValidations';
import { faDollarSign, faTag, faUser } from '@fortawesome/free-solid-svg-icons';
import { zodResolver } from '@hookform/resolvers/zod';
import { FormProvider, useForm } from 'react-hook-form';

export default function MakePaymentPage() {
    const makePaymentForm = useForm<MakePaymentData>({
        resolver: zodResolver(makePaymentSchema)
    });

    const { handleSubmit } = makePaymentForm;

    function makePayment(data: MakePaymentData) {
        console.log(data);
    }

    return (
        <FormProvider {...makePaymentForm}>
            <Form.Container
                sendButtonTitle="Realizar"
                onSubmit={handleSubmit(makePayment)}
                className="lg:w-11/12 xl:w-7/12"
            >
                <Form.Title>Pagamento</Form.Title>
                <Form.InputsGroup>
                    <Form.SplitedGroup>
                        <Form.Input
                            name="paymentAmount"
                            placeholder="Valor a ser pago..."
                            icon={faDollarSign}
                        />
                        <Form.Input
                            name="paymentType"
                            placeholder="Tipo de pagamento..."
                            icon={faTag}
                        />
                    </Form.SplitedGroup>
                    <Form.TextArea
                        name="paymentDescription"
                        placeholder="Breve descrição..."
                        className="h-48"
                    />
                    <Form.Input
                        name="paymentReceiver"
                        placeholder="Recebedor..."
                        icon={faUser}
                    />
                </Form.InputsGroup>
            </Form.Container>
        </FormProvider>
    );
}
