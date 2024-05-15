import Footer from '@/components/Footer';
import Form from '@/components/Form';
import Header from '@/components/Header';
import { faUser } from '@fortawesome/free-solid-svg-icons';

export default function pocPage() {
    return (
        <div className="w-screen h-screen">
            <Header />

            <Form.Background>
                <Form.Container sendButtonTitle="Ação">
                    <Form.Title>Formulário</Form.Title>
                    <Form.InputsGroup>
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
