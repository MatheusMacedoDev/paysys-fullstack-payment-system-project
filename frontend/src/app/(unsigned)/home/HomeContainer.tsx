import { ReactNode } from 'react';

interface HomeContainerProps {
    children: ReactNode;
}

export default function HomeContainer({ children }: HomeContainerProps) {
    return <div className="p-28 space-y-60">{children}</div>;
}
