import { ReactNode } from 'react';

interface ArticleGroupProps {
    children: ReactNode;
}

export default function ArticleGroup({ children }: ArticleGroupProps) {
    return <article className="space-y-12">{children}</article>;
}
