import { ReactNode } from 'react';

interface ItemsWrapperProps {
    children: ReactNode;
}

export default function ItemsWrapper({ children }: ItemsWrapperProps) {
    return <article className="space-y-2.5 mt-4">{children}</article>;
}
