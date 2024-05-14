import Footer from '@/components/Footer';
import Form from '@/components/Form';
import Header from '@/components/Header';

export default function pocPage() {
    return (
        <div className="w-screen h-screen">
            <Header />

            <div className="flex items-center justify-center py-20">
                <Form.Container>
                    <Form.Title>Formulário</Form.Title>
                    <Form.InputsGroup>
                        <Form.Input placeholder="Input 1" />
                        <Form.Input placeholder="Input 2" />
                        <Form.Input placeholder="Input 3" />
                    </Form.InputsGroup>
                </Form.Container>
            </div>

            <Footer />
        </div>
    );
}
