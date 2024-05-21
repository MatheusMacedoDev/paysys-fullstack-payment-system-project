import CardContainer from './CardContainer';

interface BigCardProps {
    title: string;
    description: string;
}

export default function BigCard({ title, description }: BigCardProps) {
    return (
        <CardContainer className="md:w-[572px] p-10 gap-5">
            <h1 className="font-black text-3xl">{title}</h1>
            <p className="font-normal text-xl">{description}</p>
        </CardContainer>
    );
}
