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
                </Form.Container>
            </div>

            <Footer />
        </div>
    );
}
