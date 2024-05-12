import Button from '@/components/Button';
import HomeContainer from './HomeContainer';
import HomeSection from './HomeSection';
import Image from 'next/image';

export default function Home() {
    return (
        <HomeContainer>
            <HomeSection.Container className="flex-col-reverse">
                <HomeSection.ArticleGroup>
                    <HomeSection.Heading>
                        Faça pagamentos com simplicidade
                    </HomeSection.Heading>
                    <HomeSection.Description>
                        Com o PaySys é possível fazer uma série de transações do
                        dia-a-dia, com grande simplicidade, agilidade e
                        transparência. Basta criar rapidamente uma conta fazer
                        seu depósito e então poderá fazer transações com
                        tranquilidade.
                    </HomeSection.Description>
                    <Button
                        title="Criar Conta"
                        buttonSize="medium"
                        buttonColor="dark"
                    />
                </HomeSection.ArticleGroup>
                <Image
                    src="undraw-credit-card-payment.svg"
                    alt="Pessoas fazendo uma transferência usando cartão de crédito."
                    className="w-full lg:w-auto"
                    width={526}
                    height={352}
                />
            </HomeSection.Container>

            <HomeSection.Container>
                <Image
                    src="undraw-shopping-bags.svg"
                    alt="Pessoas carregando compras."
                    className="w-full lg:w-auto"
                    width={492}
                    height={342}
                />
                <HomeSection.ArticleGroup>
                    <HomeSection.Heading>
                        Beneficios para lojistas
                    </HomeSection.Heading>
                    <HomeSection.Description>
                        Lojistas, além de poder receber os pagamentos de seus
                        clientes, ainda tem acesso a um dashboard exclusivo que
                        permite verificar os dados de suas vendas.
                    </HomeSection.Description>
                    <Button
                        title="Trabalhe Conosco"
                        buttonSize="medium"
                        buttonColor="dark"
                    />
                </HomeSection.ArticleGroup>
            </HomeSection.Container>
        </HomeContainer>
    );
}
