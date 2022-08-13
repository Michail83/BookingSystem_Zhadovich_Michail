const LEFT_PAGE = "LEFT";
const RIGHT_PAGE = "RIGHT";

const range = (from, to, step = 1) => {
    let i = from;
    const range = [];

    while (i <= to) {
        range.push(i);
        i += step;
    }

    return range;
};

const createArrayWithPageNumber = (totalPages, currentPage, pageNeighbours) => {

    let validatedPageNeighbours = typeof pageNeighbours === "number"
        ? Math.max(0, Math.min(pageNeighbours, 2))
        : 0;

    const totalNumbers = validatedPageNeighbours * 2 + 3;
    const totalBlocks = totalNumbers + 2;

    if (totalPages > totalBlocks) {
        let pages = [];

        const leftBound = currentPage - pageNeighbours;
        const rightBound = currentPage + pageNeighbours;
        const beforeLastPage = totalPages - 1;

        const startPage = leftBound > 2 ? leftBound : 2;
        const endPage = rightBound < beforeLastPage ? rightBound : beforeLastPage;

        pages = range(startPage, endPage);

        const pagesCount = pages.length;
        const additionalNumbers = totalNumbers - pagesCount - 1;

        const leftSpill = startPage > 2;
        const rightSpill = endPage < beforeLastPage;

        const leftSpillPage = LEFT_PAGE;
        const rightSpillPage = RIGHT_PAGE;

        if (leftSpill && !rightSpill) {
            const extraPages = range(startPage - additionalNumbers, startPage - 1);
            pages = [leftSpillPage, ...extraPages, ...pages];
        } else if (!leftSpill && rightSpill) {
            const extraPages = range(endPage + 1, endPage + additionalNumbers);
            pages = [...pages, ...extraPages, rightSpillPage];
        } else if (leftSpill && rightSpill) {
            pages = [leftSpillPage, ...pages, rightSpillPage];
        }
        return [1, ...pages, totalPages];
    }
    return range(1, totalPages);
}





export default createArrayWithPageNumber;
