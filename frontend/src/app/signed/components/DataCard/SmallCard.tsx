import CardContainer from './CardContainer';

interface SmallCardProps {
    title: string;
    description: string;
}

export default function SmallCard({ title, description }: SmallCardProps) {
    return (
        <CardContainer className="w-[224px] min-h-[224px] p-5 gap-5">
            <h1 className="font-bold text-2xl">{title}</h1>
            <p className="font-light text-xl">{description}</p>
        </CardContainer>
    );
}
