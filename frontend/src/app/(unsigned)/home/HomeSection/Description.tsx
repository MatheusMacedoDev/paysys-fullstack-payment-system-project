import { ReactNode } from 'react';

interface DescriptionProps {
    children: ReactNode;
}

export default function Description({ children }: DescriptionProps) {
    return <p className="font-medium text-xl text-green-300">{children}</p>;
}
