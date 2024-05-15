import Form from '@/components/Form';
import { faEnvelope, faKey } from '@fortawesome/free-solid-svg-icons';

export default function Login() {
    return (
        <Form.Background>
            <Form.Container sendButtonTitle="Entrar">
                <Form.Title>Entre na sua conta</Form.Title>
                <Form.InputsGroup>
                    <Form.Input placeholder="E-mail" icon={faEnvelope} />
                    <Form.Input placeholder="Senha" icon={faKey} />
                </Form.InputsGroup>
            </Form.Container>
        </Form.Background>
    );
}
