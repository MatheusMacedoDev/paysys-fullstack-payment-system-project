import Image from 'next/image';
import { DataCard } from '../../components/DataCard';

export default function AboutPage() {
    return (
        <>
            <Image
                src="/undraw-team-spirit.svg"
                alt="Equipe reunida demonstrando o espírito de equipe."
                className="w-full sm:w-[400px] mt-20 lg:mt-28 mb-16"
                width={338}
                height={228}
            />

            <DataCard.BigCard
                title="Sobre o PaySys"
                description={`
                    PaySys é um sistema de pagamento unificado que atende tanto B2B
                    - empresa pra empresa - quanto B2C - empresa para consumidor.`}
            />

            <Image
                src="/undraw-my-answer.svg"
                alt="Pessoa observando as respostas para as suas dúvidas."
                className="w-full sm:w-[400px] mt-36 mb-16"
                width={325}
                height={252}
            />

            <DataCard.SmallCardGroup className="pb-28">
                <DataCard.SmallCard
                    title="Simplicidade"
                    description="Com uma interface de usuário fácil de entender."
                />
                <DataCard.SmallCard
                    title="Transparência"
                    description="As tranferências são registradas e podem ser auditadas."
                />
                <DataCard.SmallCard
                    title="Facilidade"
                    description="Tudo pode ser feito em poucos passos."
                />
            </DataCard.SmallCardGroup>
        </>
    );
}
